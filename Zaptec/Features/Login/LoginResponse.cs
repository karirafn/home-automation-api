﻿namespace Zaptec.Features.Login;

public record LoginResponse(string AccessToken, string TokenType, int ExpiresIn);
