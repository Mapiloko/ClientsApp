import React,{useEffect, useState} from 'react';
import NativeSelect from '@mui/material/NativeSelect';
import FormControl from '@mui/material/FormControl';
import InputLabel from '@mui/material/InputLabel';
import FormControlLabel from '@material-ui/core/FormControlLabel'
import Checkbox from '@material-ui/core/Checkbox'
import FormGroup from '@material-ui/core/FormGroup'
import { useNavigate } from 'react-router-dom';


export default function UnlinkClient() {
    const navigate = useNavigate()
    const [clientsToUnlink, setClientsToUnlink] = useState([])
    const [saved, setSaved] = useState(false)
    var clients = JSON.parse(localStorage.getItem("clients"));
    var contacts = JSON.parse(localStorage.getItem("contacts"));
    const [value, setValue] = useState("")
    const [displayClients, setDisplayClients] = useState([])

    const sorterClients = (a, b) => {
      if (a.name < b.name) {
        return -1;
      }
      if (a.name > b.name) {
        return 1;
      }
      return 0;
    };

    useEffect(()=>{
      if(contacts.length > 0)
      {
        let clits = []
        const nn = contacts[0].clientsIDs
        for(let i=0;i < nn.length;i++)
        {
          clients.forEach(client => {
            if(client.key === nn[i])
            clits.push(client)
          });
        }
        clits.sort(sorterClients)
        setDisplayClients(clits)
      }
  },[])

  const unlinkClients=()=>{ 
    setSaved(true)
    if(clientsToUnlink.length !== 0)
    {
      displayClients.forEach((cl)=>{
        cl.checked = false
      })

      const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ key:value,clients: clientsToUnlink })
      };

      fetch(`https://localhost:5000/api/contact/${value}`, requestOptions)
          .then(response => response.json())
          .catch(e=> console.log(e))
    }
  }

  const handleChangeSelect = (e)=>{
    setClientsToUnlink([])
    setSaved(false)
    setValue(e.target.value)
    var chek = contacts.filter((contact)=>{
      return contact.key === e.target.value;
    })
    const contact = chek[0]
    let clits = []

    clients.forEach(client => {
      if(contact.clientsIDs.includes(client.key))
        clits.push(client)
    });
    clits.sort(sorterClients)
    setDisplayClients(clits)
  }

  const handleChangeCheck=(e, key)=>{
    setSaved(false)
    displayClients.forEach((cl)=>{
      if(cl.key===key)
      {
        let newvalue = cl
        newvalue.checked = !cl.checked

        var newValues = displayClients.filter((c)=>{
          return c.key !== key;
        })
        newValues.push(newvalue)
        newValues.sort(sorterClients)
        setDisplayClients(newValues)
        if(newvalue.checked)
        {
          setClientsToUnlink([...clientsToUnlink, key])
        }
        else
        {
          const index = clientsToUnlink.indexOf(key);
          if (index > -1) { 
            clientsToUnlink.splice(index, 1);
          }
        }
      }
    })
  }

  return (
    <>
      <div className='row my-3'>
        <div className='col-md-6'>
          <h3>Select Contact</h3>
        </div>
        <div className='col-md-6'>
          <h3>Select Clinets To Unlink</h3>
        </div>
      </div>
      <div className='row'>
        <div className='col-md-6'>
          <div style={{width:"70%"}}>
            <FormControl fullWidth>
                {/* <InputLabel variant="standard" htmlFor="uncontrolled-native">
                  Contact
                </InputLabel> */}
                <NativeSelect
                  value={value}
                  onChange={(e)=>handleChangeSelect(e)}
                  inputProps={{
                    name: 'age',
                    id: 'uncontrolled-native',
                  }}
                >
                  {contacts.map((contact)=>{
                    return <option key={contact.key} value={contact.key}>{contact.name}</option>
                  })}
                </NativeSelect>
              </FormControl>
          </div>
        </div>
        <div className='col-md-6 text-center my-3'>
          <FormGroup id='selects'>
            {displayClients.map((client)=>{
              return <FormControlLabel onChange={(e)=>handleChangeCheck(e,client.key)} value={client.name} 
              key={client.key} control={<Checkbox checked={client.checked} />} label={client.name} />
            })}
          </FormGroup>
        </div>
      </div>
      {
        clientsToUnlink.length === 0 && saved &&
        <div className='col-md-12 text-center'>
          <p className=' text-center' style={{color:"red"}}>Select at least one client*</p>
        </div>
      }
      <div className='col-md-12 text-center my-3'>
        <button className='saveBtn text-center' onClick={unlinkClients}>
            Unlink Contact(s)
        </button>
      </div>
      <div className='col-md-12 text-center'>
        <button className='float-end goback' onClick={()=>navigate('/')}>
            Go Back
        </button>
      </div>
    </>
    )
}
