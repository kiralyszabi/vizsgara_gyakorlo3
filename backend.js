const express = require('express')
const mysql = require('mysql')
var cors = require('cors')
const app = express()
const port = 3000
app.use(express.json())
app.use(cors())

var connection;
function kapcsolat() {
  connection = mysql.createConnection({
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'euroskills'
  })
  connection.connect()
}



app.get('/', (req, res) => {
  res.send('Hello World!')
})



app.get('/versenyzoLeKerdez', (req, res) => {
  kapcsolat()
  connection.query(`
    SELECT * from versenyzo
      `, (err, rows, fields) => {
    if (err) {
      console.log("Hiba")
      res.status(500).send("Hiba")
    }
    else {
      console.log(rows)
      res.status(200).send(rows)
    }
  })
  connection.end()
})

app.post('/dijazasFelvitel', (req, res) => {
  kapcsolat()
    connection.query(`
    INSERT INTO dijazas  VALUES (null,?, ?, ?);
        `,[req.body.bevitel1, req.body.bevitel2, req.body.bevitel3], (err, rows, fields) => {
      if (err) {
        console.log("Hiba")
        res.status(500).send("Hiba")
      }
      else {
        console.log("A felvitel sikeres!")
        res.status(200).send("A felvitel sikeres!")
      }
    })
    connection.end()
  })


app.listen(port, () => {
  console.log(`Example app listening on port ${port}`)
})

