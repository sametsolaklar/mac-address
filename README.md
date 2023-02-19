'builder.Services.Configure<ForwardedHeadersOptions>(option =>
{
    option.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});'
