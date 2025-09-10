import React, { useState } from 'react'
import Navigation from './Navigation';

export default function Contact(props) {
 const details = props.info;  
 console.log(details)
 const[state, setState] =useState({
    contact : props.info
 })
 
 const onUpdate = (ev)=>{
    setState({...state, contact: {
        ...state.contact, [ev.target.name] : [ev.target.value]
    }})
    alert(JSON.stringify(state))
 }
  return (
    <>
    {/* {JSON.stringify(details)} */}
    <div className="card">
        <h2>{details.name}</h2>
        <input name='id' className='form-control' value={details.id} onChange={(e) => onUpdate(e)}/>
        <input name='name' className='form-control' value={details.name} onChange={(e) => onUpdate(e)}/>
        <input name='phoneNo' className='form-control' value={details.phoneNo} onChange={(e) => onUpdate(e)}/>
        <Navigation id={details.id}/>
    </div>
    </> 
        // <div className="card">
        //     <div className="card-body">
        //         <div className="row">
        //             <div className="col-md-4">

        //             </div>
        //             <div className="col-md-5">
        //                 <input type="text" name='id' className='form-control' value={details.id} onChange={onUpdate} />
        //                 <input type="text" name='name' className='form-control' value={details.name} onChange={onUpdate}  />
        //                 <input type="text" name='phoneNo' className='form-control' value={details.phoneNo} onChange={onUpdate}  />
        //             </div>
        //             <div className="col-md-3">
        //                 <Navigation id ={details.id}/>
        //             </div>
        //         </div>
        //     </div>
        // </div>
       
  )
}
