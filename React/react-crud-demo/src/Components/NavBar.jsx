import React from 'react'
import { Link } from 'react-router-dom'

export default function NavBar() {
  return (
    <div>
        <nav className='navbar navbar-danger navbar-expand-sm'>
            <div className="container">
                <Link to={'/'} className='navbar-brand'>
                    <span className='text-info'>All Contacts</span>
                </Link>
                <Link to={'/contacts/new'} className='btn btn-warning text-dark'>
                    <span className='text-danger'>New Contact</span>
                </Link>
            </div>
        </nav>
    </div>
  )
}
