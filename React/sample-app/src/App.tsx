import Footer from "./Footer"
import Header from "./Header"
import Profile from "./Profile"
import UserInfo from "./UserInfo"

//Every React Component is simply a Function which is exported. The Consumer shall import the component and use in his application. These are called as Functional Components. 
function App() {
  const username : string = "Phaniraj";
  return (
    <div>
      <Header></Header>
      <Profile/>
      <UserInfo name={username} age={48} isStudent={false}/>  
      <UserInfo name="Suresh" isStudent={true}/>{/*<!--No need to fill all the props -->*/ }
      <Footer></Footer>
    </div>
  )
}

export default App
