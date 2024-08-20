﻿using System.Net;

namespace ExceptionManager.Model;

public class CannotAddTypeException(Type type) : Exception($"Cannot aggregate the type {type.Name.ToUpper()} to list.")
{
    public static HttpStatusCode HttpStatusCode => HttpStatusCode.BadRequest;
}
