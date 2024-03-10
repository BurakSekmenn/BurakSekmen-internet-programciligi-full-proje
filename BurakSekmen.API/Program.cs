using Autofac;
using Autofac.Extensions.DependencyInjection;
using BurakSekmen.API.Filters;
using BurakSekmen.API.Modules;
using BurakSekmen.Repository.Context;
using BurakSekmen.Service.Mapping;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ValidateFilterAttribute());
}).AddFluentValidation(x =>
{
    x.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});// ModelStateInvalidFilter'� devre d��� b�rak�r.



builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"), o =>
    {
        o.MigrationsAssembly("BurakSekmen.Repository");
    });
});

builder.Host.UseServiceProviderFactory(
    new AutofacServiceProviderFactory()
);
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new RepoServiceModul());
});




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(NotFoundFilter<>));
builder.Services.AddAutoMapper(typeof(MapProfile));

var app = builder.Build();

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
