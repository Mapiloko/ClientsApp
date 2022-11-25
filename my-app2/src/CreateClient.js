import React, {useEffect, useRef, useState } from 'react';
import FormControlLabel from '@material-ui/core/FormControlLabel'
import FormGroup from '@material-ui/core/FormGroup'
import Checkbox from '@material-ui/core/Checkbox'
import { useNavigate } from 'react-router-dom';
import { v4 as uuid } from 'uuid';


export default function CreateClient({contacts, codes, setClients}) {

  const [name, setName] = useState("")
  const [likedC, setLinked] = useState([])
  const [error, setError] = useState(false)
  const [typing, setTyping] = useState(false)
  const [displayContacts, setDisplayContacts] = useState([])
  const [valueSaved, setvalueSaved] = useState(false)
  const navigate = useNavigate()


  const sorterContacts = (a, b) => {
    if (`${a.name}${a.surName} ` < `${b.name}${b.surName}` ) {
      return -1;
    }
    if (`${a.name}${a.surName} ` > `${b.name}${b.surName}` ) {
      return 1;
    }
    return 0;
  };

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
          setTyping(false)
        if(name.length===0)
          setError(true)
        else{
          setError(false)
          setvalueSaved(true)
          setTimeout(() => {
            setvalueSaved(false)
          }, 1500);

          displayContacts.forEach((cl)=>{
            cl.checked = false
          })
          var code = generateCode()
  
          const unique_id = uuid();
  
          setClients({key: unique_id, linkedContacts: likedC.length, name: name, code: code, checked: false})
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

    useEffect(()=>{
      contacts.sort(sorterContacts)
      setDisplayContacts(contacts)
    },[])


    const linkContacts = (e, key)=>{
      displayContacts.forEach((cl)=>{
        if(cl.key===key)
        {
          let newvalue = cl
          newvalue.checked = !cl.checked
  
          var newValues = displayContacts.filter((c)=>{
            return c.key !== key;
          })
          newValues.push(newvalue)
          newValues.sort(sorterContacts)
          setDisplayContacts(newValues)
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
              onChange={(e)=>{
                setTyping(true)
                setName(e.target.value)
              }}
          />
          {error && !typing &&
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
          {displayContacts.map((contact)=>{
            return <FormControlLabel onChange={(e)=>linkContacts(e,contact.key)} 
            value={contact.name} key={contact.key} control={<Checkbox checked={contact.checked} />} label={contact.name} />
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
            <h6 className='text-center' style={{color:"green"}}>Client Saved</h6>
        </div>
      }
    </div>
  )
}
