# AFI.Demo

This is a demo project for the AFI task. Feel free to download and run the application.

## Storage
Storage uses an in memory instance of SQLite.

## API
The API is a simple RESTful API with the following endpoints:

* POST `/customers`
* GET `/customers/{id}`

A swagger UI is available at `/swagger/index.html`

# Structure
Much of th requirements are implemented within the `/Features/Customers` folder. The `Features` folder is intended to give an area where vertical slices of functionality reside within our application. In this case `Customer` functionality.

## Validation
Validation uses [FluentValidation](https://docs.fluentvalidation.net/en/latest/) and is triggered by a ValidationBehaviour which is assigned to the [MediatR](https://github.com/jbogard/MediatR) pipeline, which allows us to decouple the more complex logic from the controller presentation layer.

## Testing
The project has a sample unit test project using xUnit to perform tests on the validation logic.