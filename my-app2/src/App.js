import './App.css';
import React, {useState, useEffect } from 'react';
import {BrowserRouter as Router, Routes , Route } from "react-router-dom"
import Home from './Home';
import CreateContact from './CreateContact'
import CreateClient from './CreateClient'
import UnlinkClient from './UnlinkClient'



function App() {

  const [contacts, setContacts] = useState([])
  const [contact, setContact] = useState(null)
  const [clients, setClients] = useState([])
  const [emails, setEmails] = useState([])

  useEffect(()=>{
    fetch('https://localhost:7208/api/contact')
        .then(response => response.json())
        .then((data) =>{
          setContact(data)
          let arr = []
          data.forEach(element => {
            arr.push(element.email)
          });

          setEmails(arr)
        });

    fetch('https://localhost:7208/api/client')
        .then(response => response.json())
        .then((data) =>{
          setClients(data)
        });
  },[])

  return (
    <div className='container'>
      <Router>
        <h1 className='header' >OUR CLIENTS APP</h1>

        <Routes >
        <Route path="/" element={<Home setContact={(e)=>setContact(e)} clients={clients} contacts={contacts} />} />
        <Route path="/createcontact" element={<CreateContact emails={emails} setContacts={(e)=>
        { setEmails([...emails, e.email])
          setContacts([...contacts, e])
        }} clients={clients} contacts={contacts}/>} />
        <Route path="/createclient" element={<CreateClient setClients={(e)=>setClients([...clients, e])} clients={clients} contacts={contacts} />} />
        <Route path="/unlinkclient" element={<UnlinkClient clients={clients} contact={contact}/>} />
        </Routes >
      </Router>
    </div>
  );
}

export default App;
