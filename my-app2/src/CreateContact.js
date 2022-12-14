import React, {useState,useEffect } from 'react';
import { v4 as uuid } from 'uuid';
import FormControlLabel from '@material-ui/core/FormControlLabel'
import FormGroup from '@material-ui/core/FormGroup'
import Checkbox from '@material-ui/core/Checkbox'
import { useNavigate } from 'react-router-dom';
export default function CreateContact({emails, clients, setContacts}) {

  const [name, setName] = useState("")
  const [surname, setSurname] = useState("")
  const [email, setEmail] = useState("")
  const [emailvalid, setValidEmail] = useState(true)
  const [likedC, setLinked] = useState([])
  const [displayClients, setDisplayCliets] = useState([])
  const [saveValue, setsaveValue] = useState(true)
  const [valueSaved, setvalueSaved] = useState(false)
  const [saved, setSaved] = useState(false)
  const [message, setMessage] = useState("")
  const navigate = useNavigate()


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
    clients.sort(sorterClients)
    setDisplayCliets(clients)
  },[])
    const SaveContact =()=>{
        if(name.length ===0 || email.length === 0 || surname.length ===0)
          setSaved(true)
        else{
          setsaveValue(false)
          setTimeout(() => {
              setsaveValue(true)
          }, 1000);

          displayClients.forEach((cl)=>{
            cl.checked = false
          })

          const unique_id = uuid();
          setContacts({name: name, surName: surname, email: email,linkedClients: likedC.length, key : unique_id, checked: false})
  
          const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({key : unique_id, name: name, surName: surname, clients:likedC, email: email})
          };
  
          fetch('https://localhost:5000/api/contact', requestOptions)
              .then(response => response.json())
              .catch(e=> console.log(e))
  
          setvalueSaved(true)
          setEmail("")
          setName("")
          setSurname("")
          setSaved(false)
        }
    }

    const linkClients = (e, key)=>{
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
          setDisplayCliets(newValues)
          if(newvalue.checked)
          {
            setLinked([...likedC, key])
          }
          else
          {
            const index = likedC.indexOf(key);
            if (index > -1) { 
              likedC.splice(index, 1);
            }
          }
        }
      })
    }
    const checkEmail = (e)=>{
      setEmail(e.target.value)
      if(!/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(e.target.value))
      {
        setMessage("Please enter valid email addess")
        setValidEmail(false)
      }
      else if(emails.includes(e.target.value))
      {
        setMessage("Enter Unique Email Address")
        setValidEmail(false)
      }
      else
        setValidEmail(true)
    }

    const goBack = ()=>{
      navigate('/')
    }


  return (
    <div>
      <h3>Creating New Contact:</h3>
      <div className='row clinetcontent'>
        <div className='col-md-6 my-3'>
            <label className='labelInput'>Contact Name :</label>
        </div>
        <div className='col-md-6 my-3'>
          <input
              value={name}
              className='w-100'
              id="outlined-name"
              label="Name"
              placeholder="Enter name"
              onChange={(e)=>setName(e.target.value)}
          />
          {name.length===0 && saved &&
            <>
                <p style={{color:"red", marginBottom:"-1rem"}}>Name field is required*</p>
            </>
          }
        </div>
        <div className='col-md-6 my-3'>
            <label className='labelInput'>Contact Surname :</label>
        </div>
        <div className='col-md-6 my-3'>
          <input
              value={surname}
              className='w-100'
              id="outlined-name"
              label="Name"
              placeholder="Enter name"
              onChange={(e)=>setSurname(e.target.value)}
          />
          {surname.length===0 && saved &&
            <>
                <p style={{color:"red", marginBottom:"-1rem"}}>Surname field is required*</p>
            </>
          }
        </div>
        <div className='col-md-6 my-3'>
            <label className='labelInput'>Email Address :</label>
        </div>
        <div className='col-md-6 my-3'>
          <input
              value={email}
              className='w-100'
              id="outlined-name"
              label="Name"
              placeholder="Enter Email"
              onChange={(e)=>checkEmail(e)}
          />
          {email.length===0 && saved &&
            <>
                <p style={{color:"red", marginBottom:"-1rem"}}>Email field is required*</p>
            </>
          }
          {email.length!==0 &&
            <p style={{color: "red",display: emailvalid && "none"}}>{message}*</p>
          }
        </div>
        <div className='col-md-6' style={{display: clients.length=== 0  && "none" }} >
            <label className='labelInput'>Link Clients :</label>
        </div>
        <div className='col-md-6'>
        <FormGroup>
          {displayClients.map((client)=>{
            return <FormControlLabel onChange={(e)=>linkClients(e,client.key)} 
            value={client.name} key={client.key} control={<Checkbox checked={client.checked} />} label={client.name} />
          })}
        </FormGroup>
        </div>
      <div className='col-md-12 text-center'>
        <button className='saveBtn text-center' onClick={SaveContact}>
            Save
        </button>
      </div>
      </div>
      <div className='col-md-12 text-center'>
        <button className='float-end goback' onClick={goBack}>
            Go Back
        </button>
      </div>
      {valueSaved && 
          <h6 className='text-center' style={{color:"green", display: saveValue && "none" }}>Contact Saved</h6>
      }
    </div>

  )
}
