using uni_project.Core.Extentions;
using uni_project.DataBase;
using uni_project.Repositrory.UserRepository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<Connection>();
builder.Services.AddTransient<UserDB>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddTransient<Validations>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
