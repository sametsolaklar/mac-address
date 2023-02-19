#  Using MVC
Add to your Program.cs
```sh
builder.Services.Configure<ForwardedHeadersOptions>(option =>
{
    option.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});
```
# Using Blazor
Add to your Program.cs 
```sh
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<ForwardedHeadersOptions>(option =>
{
    option.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});
```
App Integration

# Blazor in code using C#
```sh
@inject IHttpContextAccessor httpContextAccessor
IPAddress remoteIP = httpContextAccessor.HttpContext.Connection.RemoteIpAddress;
```
# MVC in code using C#
```sh
IPAddress remoteIP = Request.HttpContext.Connection.RemoteIpAddress;
```

# 

