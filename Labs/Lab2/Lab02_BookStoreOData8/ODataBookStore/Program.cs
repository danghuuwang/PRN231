using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBookStore.DatabaseContext;
using ODataBookStore.Models;

// GetEdmModel() is a helper method to create an ODataConventionModelBuilder and configure the model.
static IEdmModel getEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Book>("Books");
    builder.EntitySet<Press>("Presses");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseInMemoryDatabase("BookList"));

builder.Services.AddControllers();

builder.Services.AddControllers().AddOData(option =>
    option.Select().Filter().Count().OrderBy().SetMaxTop(100).AddRouteComponents("odata", getEdmModel()));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Register the Odata Endpoint
app.UseODataBatching();

// Test middleware
// app.Use(async (context, next) =>
// {
//     var endpoint = context.GetEndpoint();
//     if (endpoint == null) next(context);
//
//     IEnumerable<string> templates;
//     var metadata = endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
//     if (metadata != null) templates = metadata.Template.GetTemplates();
//
//     next(context);
// });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();