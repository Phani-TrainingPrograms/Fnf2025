import axios from "axios";
export class ContactService{
    static baseUrl ="http://localhost:3000/contacts";

    //5 Functions for CRUD operations:
    static getAllContacts = () => axios.get(this.baseUrl);

    static getContactById = (id) => axios.get(`${this.baseUrl}/${id}`);

    static addContact = (c) => axios.post(this.baseUrl, c);

    static deleteContact = (id) =>{
        const url = `${this.baseUrl}/${id}`;
        return axios.delete(url);
    }

    static updateContact = (c) =>{
        const url = `${this.baseUrl}/${c.id}`;
        return axios.put(url, c);
    }

}