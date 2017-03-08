namespace ValidicCSharp.Model
{
    public enum StatusCode
    {
        /// <summary>
        ///     Request was successful
        /// </summary>
        Ok = 200,

        /// <summary>
        ///     POST request was successfully created
        /// </summary>
        Created = 201,

        /// <summary>
        ///     Request was not authorized
        /// </summary>
        Unauthorized = 401,

        /// <summary>
        ///     Request was forbidden, wrong access token supplied
        /// </summary>
        Forbidden = 403,

        /// <summary>
        ///     Resource was not found
        /// </summary>
        NotFound = 404,

        /// <summary>
        ///     Supplied POST data was not accepted
        /// </summary>
        NotAcceptable = 406,

        /// <summary>
        ///     Resource could not processed due to a conflict (e.g. user already exists)
        /// </summary>
        Conflict = 409,

        /// <summary>
        ///     Resource could not be processed, wrong parameters or credentials supplied
        /// </summary>
        UnprocessableEntity = 422
    }
}