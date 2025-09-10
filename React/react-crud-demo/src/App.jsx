import { useState } from 'react'
import './App.css'
import Calc from './Ex02Calc';
import ArrayState from './Ex03ArrayState';
import FetchApiDemo from './Ex04FetchApiDemo';
import NavBar from './Components/NavBar';
import { Navigate, Routes, Route } from 'react-router-dom';
import ContactList from './Components/ContactList';
import EditContact from './Components/EditContact';
import ViewContact from './Components/ViewContact';
import AddContact from './Components/AddContact';
import Contact from './Components/Contact';
//React Hooks: Sp functions that allow components(Functional) to use the React features without writing the old style Class Components which was available in the older React versions. (16.8). 
//useState, useEffect, useContext, useReducer, useCallback, useRef and many more. 
//useState: Its a react hoot that allows to create a variable that maintains a state(capability to hold the value). every variable will have a setter function that sets the value in the Virtual DOM.  
function App() {

  const contact = {
    "id": 1,
    "phoneNo": 9945205684,
    "name": "Phaniraj ",
    "photo": "Phani.png"
  }
  let[name, setName ] = useState("Guest");//U have created a variable that shall hold the data across the page loads.....
  let[age, setAge] = useState(48)

  function updateName(){
    setName("Phaniraj")
    setAge((a) => a + 1)
  }
  return (
    <>
    {/* <div>
      <h1>Use state Example</h1>
    
      <h2>Example of react App</h2>
      <hr />
      <p>
        Name: {name}
        <button onClick={updateName}>Change Name</button>
      </p>
      <p>
        Age: {age}
      </p>
    </div>
    <Calc></Calc>
    <ArrayState></ArrayState> 
    <FetchApiDemo/>*/}
    <NavBar/>
    <Routes>
      <Route path= {'/'} element = { <Navigate to={'/contacts/all'}/> }/>
      <Route path= {'/contacts/all'} element = { <ContactList /> }/>
      <Route path= {'/contacts/edit/:id'} element = { <EditContact/>  }/>
      <Route path= {'/contacts/view/:id'} element = { <ViewContact/>  }/>
      <Route path= {'/contacts/new' } element = { <AddContact/> }/>
    </Routes>
    </>
  )
}

export default App
