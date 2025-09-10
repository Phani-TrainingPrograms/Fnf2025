import React, { useState } from 'react'

export default function ArrayState() {
  const [ foods, setFoods] = useState(["Idly", "Pongal", "Coffee"])
  
  const addNewFood = () =>{
    const value = document.getElementById("foodInput").value;
    setFoods([...foods, value]);
  }

  const removeFood = (index) =>{
    debugger;
    foods.splice(index, 1);
    setFoods([...foods])
  }

  return (
    <>
        <h1>List of Food Items for the day</h1>
        <hr />
        <ul>
            {
                foods.map((f, i)=> <li key={i}>{f}
                <button onClick={() => removeFood(i)}>X</button>
                </li>)
            }
        </ul>
        <input type='text' placeholder='Add new Food' id='foodInput'/>
        <button onClick={addNewFood}>Add New Food</button>
    </>
  )
}
