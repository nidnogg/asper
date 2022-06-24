import { useEffect, useState } from 'react'
import Table from 'react-bootstrap/Table'

interface User {
    id: number,
    name: string,
    isAdmin: boolean
}
const Users = () => {
    
    const [curUsers, setCurUsers] = useState<User[]>([])
    const getUsers = async () => {
        const response = await fetch('https://localhost:7199/user')
        const users = await response.json()
        return users
    }
    
    useEffect(() => {
        getUsers().then(users => {
            console.log(`Fetching user data`)
            setCurUsers(users)
            console.log(`Finished fetching user data:`)
            console.log(curUsers)
        })
    }, []) // [] as second argument calls useEffect only once, handy for fetching

    return (
        <section>
            <Table striped hover bordered variant="dark">
                <thead>
                    <tr>
                        <th>id</th>
                        <th>name</th>
                        <th>isAdmin</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        curUsers.map(user => {
                            return (
                                <tr>
                                    <th>{user.id}</th>
                                    <td>{user.name}</td>
                                    <td>{user.isAdmin.toString()}</td>
                                </tr>
                            )
                        })
                    }
                </tbody>
            </Table>
        </section>
    )
}

export default Users