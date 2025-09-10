
//Typescript scenario.
export default function UserInfo(props: {name: string, age: number, isStudent : boolean} | null) {
    //In TS, the data type are to be defined during declaration, so you can pass null. Check for null using the ?.
  const name = props?.name;
  const age = props?.age;
  const isStudent = props?.isStudent
    return (
    <div className="card">
        <p>Name: {name}</p>
        <p>Age: {age}</p>
        <p>Student: {isStudent ? "Yes" : "Not a Student"}</p>
    </div>
  )
}

UserInfo.defaultProps = {
    name : "",
    age : 0,
    isStudent : true
}
