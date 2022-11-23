import React, {useEffect, useRef, useState } from 'react';
import FormControlLabel from '@material-ui/core/FormControlLabel'
import FormGroup from '@material-ui/core/FormGroup'
import Checkbox from '@material-ui/core/Checkbox'
import { useNavigate } from 'react-router-dom';
import { v4 as uuid } from 'uuid';


export default function CreateClient({contacts, setClients}) {

  const [name, setName] = useState("")
  const [likedC, setLinked] = useState([])
  const [error, setError] = useState(false)
  const [saveValue, setsaveValue] = useState(true)
  const [valueSaved, setvalueSaved] = useState(false)
  const navigate = useNavigate()


    const generateCode = () =>{
      const myArray = name.trim().split(" ");

      let neValue ;
      if(myArray.length > 2)
        neValue = name.charAt(0).concat(myArray[1].charAt(0).concat(myArray[2].charAt(0))).toUpperCase()
      else if(myArray.length === 2)
        neValue = name.toUpperCase().substring(0, 2).concat(myArray[1].charAt(0).toUpperCase());
      else
        {
          if(name.length == 2 )
            neValue = name.substring(0, 2).toUpperCase().concat("A")
          else if(name.length == 1)
            neValue = name.toUpperCase().concat("AB")
          else
            neValue = name.substring(0, 3).toUpperCase()
        }
      
       let nn = Math.floor(Math.random() * 999)
       if(nn < 10)
        neValue = neValue.concat("00".concat(nn.toString()))
       else if (nn < 100)
        neValue = neValue.concat("0".concat(nn.toString()))
       else
        neValue = neValue.concat(nn.toString())

        return neValue
      }
      
      const SaveClient =()=>{
        if(name.length===0)
          setError(true)
        else{
          setError(false)
          setsaveValue(false)
          setTimeout(() => {
            setsaveValue(true)
          }, 1000);
          
          var code = generateCode()
  
          const unique_id = uuid();
  
          setClients({key: unique_id, linkedContacts: likedC.length, name: name, code: code})
          const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ key: unique_id, name: name, code: code, contacts: likedC})
          };
  
          fetch('https://localhost:5000/api/client', requestOptions)
              .then(response => response.json())
              .catch(e=> console.log(e))
          setName("")
          setvalueSaved(true)
        }
    }

    const linkContacts = (e, id)=>{
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

  return (
    <div>
      <h3>Creating New Client:</h3>
      <div className='row clinetcontent'>
        <div className='col-md-6 my-3'>
            <label className='labelInput'>Client Name :</label>
        </div>
        <div className='col-md-6 my-3'>
          <input
              value={name}
              id="outlined-name"
              label="Name"
              placeholder="Enter name"
              onChange={(e)=>setName(e.target.value)}
          />
          {error &&
            <>
                <p style={{color:"red", marginBottom:"-1rem"}}>Name field is required*</p>
            </>
          }
        </div>
        <div className='col-md-6' style={{display: contacts.length ===0 && "none" }}>
            <label className='labelInput'>Link Contacts :</label>
        </div>
        <div className='col-md-6'>
        <FormGroup>
          {contacts.map((contact)=>{
            return <FormControlLabel onChange={(e)=>linkContacts(e,contact.key)} value={contact.name} key={contact.key} control={<Checkbox />} label={contact.name} />
          })}
        </FormGroup>
        </div>
      <div className='col-md-12 text-center'>
        <button className='saveBtn text-center' onClick={SaveClient}>
            Save
        </button>
      </div>
      </div>
      <div className='col-md-12 text-center'>
        <button className='float-end goback' onClick={()=>navigate('/')}>
            Go Back
        </button>
      </div>
      {valueSaved && 
        <div>
            <h6 className='text-center' style={{color:"green", display: saveValue && "none" }}>Client Saved</h6>
        </div>
      }
    </div>
  )
}
