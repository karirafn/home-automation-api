using MediatR;

namespace Zaptec.Features.Login;

public record LoginRequest(string Username, string Password) : IRequest<LoginResponse>;
