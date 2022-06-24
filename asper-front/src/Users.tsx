
import Table from 'react-bootstrap/Table';
const Users = () => {
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
                    <tr>
                        <th>1</th>
                        <td>John Doe</td>
                        <td>true</td>
                    </tr>
                </tbody>
            </Table>
        </section>
    )
}

export default Users