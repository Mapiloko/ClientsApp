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
  const [codes, setCodes] = useState([])

  const sorterClients = (a, b) => {
    if (a.name < b.name) {
      return -1;
    }
    if (a.name > b.name) {
      return 1;
    }
    return 0;
  };

  const sorterContacts = (a, b) => {
    if (`${a.name}${a.surName} ` < `${b.name}${b.surName}` ) {
      return -1;
    }
    if (`${a.name}${a.surName} ` > `${b.name}${b.surName}` ) {
      return 1;
    }
    return 0;
  };

  useEffect(()=>{
    fetch('https://localhost:5000/api/Contact')
        .then(response => response.json())
        .then((data) =>{
          data.sort(sorterContacts)
          let arr = []
          data.forEach(element => {
            element["checked"] = false;
            arr.push(element.email)
          });
          setContacts(data)
          setEmails(arr)
        });

    fetch('https://localhost:5000/api/client')
        .then(response => response.json())
        .then((data) =>{
          let arr = []
          data.forEach(element => {
            element["checked"] = false;
            arr.push(element.code)
          });
          data.sort(sorterClients)
          setClients(data)
          setCodes(arr)
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
        <Route path="/createclient" element={<CreateClient setClients={(e)=>
        { setCodes([...codes, e.code])
          setClients([...clients, e])}} clients={clients} codes={codes} contacts={contacts} />} />
        <Route path="/unlinkclient" element={<UnlinkClient clients={clients} contact={contact}/>} />
        </Routes >
      </Router>
    </div>
  );
}

export default App;
