import React, { createContext, useContext, useState } from 'react'

const baseUrl = "http://localhost:3000/contacts";
export const contactContext  = createContext([]);
//useContext is a React Hook for storing data across the components without a need to use props or any external State management libraries like Redux...

const ContactDatabase = () =>{
    const { contactsDataSource, setContactsDataSource } = useContext(contactContext);

    const contacts = contactsDataSource.map((c)=>{
        debugger;
        return(
            <div className='card'>
                <h2>{c.name}</h2>
                <hr/>
                <p>Contact: {c.phoneNo}</p>
            </div>
        )
    });

    //fetch is an API that is provided by JS to make HTTP Calls to the REST end points. Traditional React Apps use a 3rd partylib called Axios to get the data
    const handleFetch = () =>{
        fetch(baseUrl).then((res) => res.json())
        .then((data)=>{
            debugger;
            setContactsDataSource(data)
        })
    }

    return(
        <div>
            <h1>Contacts Database</h1>
            <button onClick={handleFetch}>Get Contacts</button>
            <div>
                {contacts}
            </div>
        </div>
    )
}

//Component
export default function FetchApiDemo() {
  const [contactsDataSource, setContactsDataSource] = useState([])
  return (
    <>
        <div>FetchApiDemo</div>
        <contactContext.Provider value={{contactsDataSource, setContactsDataSource}}>
            <ContactDatabase/>
        </contactContext.Provider>
    </>
  )
}
