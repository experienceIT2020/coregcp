module.exports = ({ env }) => ({
    connection: {
        client: 'postgres',
        connection: {
            host: env('DB_HOST', 'localhost'),
            port: env('DDB_PORT', 5432),
            database: env('DB_NAME'),
            user: env('DB_USER'),
            password: env('DB_PASS'),
        }
    },
});