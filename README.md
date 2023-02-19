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

# 

