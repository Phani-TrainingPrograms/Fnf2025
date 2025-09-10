import React, { useEffect, useState } from 'react'

export default function Calc() {
    const [first, setFirst] = useState(0.0)
    const [second, setsecond] = useState(0.0)
    const [operand, setOperand] = useState("Add");
    const [result, setResult] = useState(0.0)

    //Event handler for the click event of the = button...
    const getResult = (ev) =>{
        switch(operand){
            case "Add" : setResult(parseFloat(first) + parseFloat(second)); break;
            case "Subtract" : setResult(first - second); break;
            case "Multiply" : setResult(first * second); break;
            case "Divide" : setResult(first / second); break;
            default : alert("Invalid Choice"); break;
        }
    }
    //It is called whenever the Component is rendered to the Physical DOM..
    useEffect(()=> console.log("COMPONENT IS RENDERED"));
  return (
    <>
        <h1>Calc Program</h1>
        <hr />
        <div>
           <input type='number'placeholder='Enter the First Value' onChange={(e) => setFirst(e.target.value)}/>    
            <input type='number'placeholder='Enter the Second Value' onChange={(e) => setsecond(e.target.value)}/>    
            <select onChange={(e) => setOperand(e.target.value)}>
                <option>Select any option</option>
                <option>Add</option>    
                <option>Subtract</option>    
                <option>Multiply</option>    
                <option>Divide</option>    
            </select>    
            <button onClick={(ev) => getResult(ev)}>=</button>
            <span>{result}</span>
            </div>    
    </>
  )
}
