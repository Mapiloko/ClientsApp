import './App.css';
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';


export default function Home({clients, contacts}) {

    const navigate = useNavigate()
    const [toggle, setToggle] = useState(true)


    const createNewClient = (e)=>{
      if(e === "clients")
        navigate('/createclient')
      else
        navigate('/createcontact')
    }

    function openCity(evt, show) {
      var i, tablinks;
      if(show === "clients")
        setToggle(true)
      else
        setToggle(false)
      tablinks = document.getElementsByClassName("tablinks");
      for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
      }
    
      evt.currentTarget.className += " active";
    }

    // function Unlinkclient(e){
    //   console.log("eee", e)
    //   props.setContact(e)
    //   navigate('/unlinkclient')
    // }

  return (
    <div>
      <div className="tab row">
      <div className='col-md-6 px-0'>
        <button className="tablinks active w-100" onClick={(event)=>openCity(event, 'clients')}>Clients</button>
      </div>
      <div className='col-md-6 px-0'>
        <button className="tablinks w-100" onClick={(event)=>openCity(event, 'contacts')}>Contacts</button>
      </div>
      </div>

      {toggle? 
      <>
        <div style={{display: "grid", justifyContent: "center"}} >
            <button className='createClient text-center' onClick={()=>createNewClient("clients")}>
                Create New Client + 
            </button>
        </div>
          {
           clients.length===0 ? <h3 className='text-center' > No Client(s) found</h3> :
           <>
            <div className='row headings'>
              <div className='col-md-4 text-start h4'>Name</div>
              <div className='col-md-4 text-start h4'>Client Code</div>
              <div className='col-md-4 text-center h4'># of Liked Contacts</div>
            </div>

            <div className='row content'>
              {
                clients.map((client)=>{
                  return (
                    <div key={client.id} className='row item'>
                      <div className='col-md-4 text-start h6'>{client.name}</div>
                      <div className='col-md-4 text-start h6'>{client.code}</div>
                      <div className='col-md-4 text-center h6'>{client.linkedContacts}</div>
                    </div>
                  )
                })
              }
            </div>
           </>
          }
      </>
        :
        <>
          <div style={{display: "grid", justifyContent: "center"}} >
              <button className='createClient text-center' onClick={()=>createNewClient("contacts")}>
                  Create New Contact + 
              </button>
          </div>
        {
           contacts.length===0 ? <h3 className='text-center' > No Contact(s) found</h3> :
           <>
              <div className='row headings'>
                <div className='col-md-4 text-start h4'>Full Name</div>
                <div className='col-md-4 text-start h4'>Email address</div>
                <div className='col-md-4 text-center h4'># of Liked Clients</div>
              </div>

              <div className='row content'>
                {
                  contacts.map((contact)=>{
                    return (
                      <div key={contact.id} className='row item'>
                        <div className='col-md-4 text-start h6'>{`${contact.name} ${contact.surName}`}</div>
                        <div className='col-md-4 text-start h6'>{contact.email}</div>
                        <div className='col-md-4 text-center h6'>{contact.linkedClients}</div>

                        {/* <div className='col-md-4 text-center h6'><button onClick={()=>Unlinkclient(contact)} className='unlinkClient'>Unlike clients</button> </div> */}
                      </div>
                    )
                  })
                }
              </div>
           </>
        }
      </>
      }


    </div>
  )
}
