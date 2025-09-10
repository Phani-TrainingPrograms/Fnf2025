import myPic from './assets/Phani.png'
export default function Profile() {
  //data shall come here...
  const title = "Phaniraj"
  const info = "I conduct trainings on JS Frameworks"
    return (
    <div className="container">
        <div className="row">
            <div className="col-md-2"></div>
            <div className="col-md-8">
                <div className="card">
                    <img className='card-image img-thumbnail rounded-circle card-sm' src={myPic}/>
                    <h2 className="card-title">{title}</h2>
                    <hr />
                    <p className="card-text">{info}</p>
                </div>    
            </div>
        </div>
    </div>
  )
}
