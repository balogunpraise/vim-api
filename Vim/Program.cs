using Vim.Infrastructure;
using Vim.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfracstructureService(builder.Configuration);
builder.Services.AddServices(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("corspolicy", (policy) =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("StudentPolicy", (policy) =>
    {
        policy.RequireRole("Student");
    });

    options.AddPolicy("StaffPolicy", (policy) =>
    {
        policy.RequireRole("Staff");
    });

    options.AddPolicy("Administrator", (policy) =>
    {
        policy.RequireRole("Administrator");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
