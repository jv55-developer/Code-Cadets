const express = require('express');
const cookieParser = require('cookie-parser');
const app = express();
const cors = require('cors');

app.use(express.json());
app.use(cors({
    origin: "http://localhost:3000",
    methods: ["POST", "GET", "DELETE", "PUT"],
    credentials: true
}));
app.use(cookieParser())

const db = require('./models');

db.sequelize.sync().then(() => {
    app.listen(3002, () => {
        console.log("Server is running in port 3002 now!");
    });
});