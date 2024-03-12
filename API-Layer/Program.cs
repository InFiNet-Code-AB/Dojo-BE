﻿using Application_Layer;
using Application_Layer.AutoMaper;
using AutoMapper;
using Domain_Layer.Models.UserModel;
using Infrastructure_Layer;
using Infrastructure_Layer.Database;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dojo BE", Version = "v1" });
});

// AutoMaper Configuretion
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<UserProfile>();
});
builder.Services.AddSingleton(config.CreateMapper());

//  Add our own services (layers) here
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<UserModel>().AddEntityFrameworkStores<DojoDBContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dojo BE API V1");
});

app.MapIdentityApi<UserModel>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
