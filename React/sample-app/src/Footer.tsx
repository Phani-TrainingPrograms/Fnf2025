

export default function Footer() {
 const year : number = new Date().getFullYear();   
  return (
    <div>
        <i>&copy;All Rights Reserved. Powered by React 19.x-{year}</i>
    </div>
  )
}
