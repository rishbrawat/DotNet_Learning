// an entity is a simple c# class that represents a specific table in your database

// when we use ef(object relation mapper), it bridges the gap between c# code and relational database, instead of writing raw sql queries to read and write data, we interact with these entities

/*
    the class itself maps the data to the table
    the properties in the class map to table's columns
    an instance represents a single row in that table.
*/

/*
    dbcontext is the core class of entity framework, it represents a session with the databse and is responsible for managing the connection, tracking changes, and executing the database commands.

    it contains methods like SaveChanges() and SaveChangesAsync()

*/

/*
    dbset represents a collection of a specific entity type, it directly maps to a table/view in the database.

    it supports:
        LINQ queries
        CRUD operations
        Table representations
*/