import React, { useEffect, useState } from 'react'
import Contact from './Contact';
import { ContactService} from '../Services/ContactService'
export default function ContactList() {
 const [state, setState] = useState([])
  
 
  useEffect(()=>{
    async function fetchData() {
      debugger;
      const response = await ContactService.getAllContacts();
      setState(response.data);
    }
    fetchData()
  }, [])
  return (
    <>
      <div className="container">
        <h1>List of Contacts</h1>
        <div className="row">
          {
            state.map((c, _) => {
              return (
                <div className='col-md-8 m-2' key={c.id}>
                  <Contact info={c} />
                </div>
              )
            })
          }
        </div>
      </div>
    </>
  )
}
