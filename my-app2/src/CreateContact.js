import React, {useState } from 'react';
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
  const [saveValue, setsaveValue] = useState(true)
  const [valueSaved, setvalueSaved] = useState(false)
  const [message, setMessage] = useState("")
  const navigate = useNavigate()


    const SaveContact =()=>{
        setsaveValue(false)
        setTimeout(() => {
            setsaveValue(true)
        }, 1000);
        const unique_id = uuid();
        setContacts({name: name, surName: surname, email: email,linkedClients: likedC.length, key : unique_id })

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
    }

    const linkClients = (e, id)=>{
      if(e.target.checked)
      {
        setLinked([...likedC, id])
      }
      else
      {
        const index = likedC.indexOf(id);
        if (index > -1) { 
          likedC.splice(index, 1);
        }
      }
    }
    const checkEmail = (e)=>{
      setEmail(e.target.value)
      console.log("emails", emails)
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
        <div className='col-md-6'>
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
        </div>
        <div className='col-md-6'>
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
        </div>
        <div className='col-md-6'>
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
          <p
            style={{
              color: "red",
              // marginTop: "-8px",
              display: emailvalid && "none",
            }}
          >
              {message}*
          </p>
        </div>
        <div className='col-md-6' style={{display: clients.length=== 0  && "none" }} >
            <label className='labelInput'>Link Clients :</label>
        </div>
        <div className='col-md-6'>
        <FormGroup>
          {clients.map((client)=>{
            return <FormControlLabel onChange={(e)=>linkClients(e,client.key)} value={client.name} key={client.key} control={<Checkbox />} label={client.name} />
          })}
        </FormGroup>
        </div>
      <div className='col-md-12 text-center'>
        <button className='saveBtn text-center' disabled={!emailvalid || name.length==0 || surname.length === 0} onClick={SaveContact}>
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
