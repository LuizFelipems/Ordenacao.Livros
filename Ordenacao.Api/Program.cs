using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordenacao.Api.Swagger;
using Ordenacao.Application.Commons.Responses;
using Ordenacao.Application.Handlers.Books.Commands;
using Ordenacao.Application.Handlers.Books.Queries;
using Ordenacao.Application.Handlers.Books.Queries.Parameters;
using Ordenacao.Application.Handlers.Books.Responses;
using Ordenacao.Infra.CrossCutting.IoC;
using Ordenacao.Infra.Data.DataContexts.Configurations;
using Swashbuckle.AspNetCore.Annotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterServices();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();
app.Logger.LogInformation("The app started");

// Configure the HTTP request pipeline.
app.UpdateDatabase();
app.UseSwaggerDocumentation();
app.UseHttpsRedirection();

#region CSO-Serviço.de.Ordenação
app.MapPost("/v1/book-ordination", async ([FromServices] IMediator _mediator, [FromBody] OrdinationBooksCommand command) =>
{
    return await _mediator.Send(command);
}).WithTags("1 - CSO-Book")
  .Produces<Response<List<BookResponse>>>(200)
  .ProducesProblem(500)
  .WithMetadata(new SwaggerOperationAttribute("CSO - Serviço de Ordenação"));
#endregion

#region CRUDExemplo
app.MapPost("/v1/book", async ([FromServices] IMediator _mediator, [FromBody] CreateBookCommand command) =>
{
    var response = await _mediator.Send(command);

    return response.IsValid ? Results.Created($"/v1/book/{response?.Data?.Id}", response)
                            : Results.BadRequest();
}).WithTags("Book")
  .Produces<Response<BookResponse>>(201)
  .ProducesProblem(404)
  .WithMetadata(new SwaggerOperationAttribute("Create New Book"));

app.MapPut("/v1/book/{id}", async ([FromServices] IMediator _mediator, Guid id, [FromBody] UpdateBookCommand command) =>
{
    var response = await _mediator.Send(command.AssignId(id));

    return response.IsValid ? Results.Created($"/v1/book/{response?.Data?.Id}", response)
                            : Results.BadRequest();
}).WithTags("Book")
  .Produces<Response<BookResponse>>(201)
  .ProducesProblem(404)
  .WithMetadata(new SwaggerOperationAttribute("Update Existing Book"));

app.MapGet("/v1/books", async ([FromServices] IMediator _mediator, [AsParameters] GetAllBooksPaginatedParameters parameters) =>
{
    return await _mediator.Send(new GetAllBooksPaginatedQuery(parameters));
}).WithTags("Book")
  .Produces<PagedListResponse<BookResponse>>(200)
  .ProducesProblem(404)
  .WithMetadata(new SwaggerOperationAttribute("Search All Paginated Books"));

app.MapGet("/v1/book/{id}", async ([FromServices] IMediator _mediator, [FromRoute] Guid id) =>
{
    return await _mediator.Send(new GetByIdBookQuery(id));
}).WithTags("Book")
  .Produces<Response<BookResponse>>(200)
  .ProducesProblem(404)
  .WithMetadata(new SwaggerOperationAttribute("Get Book By Id"));
#endregion

app.Run();
