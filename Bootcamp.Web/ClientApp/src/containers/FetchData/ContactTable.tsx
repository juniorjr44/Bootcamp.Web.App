import { memo } from 'react';
import type { ContactState } from '../../store/contactSlice';

type ContactTableProps = Pick<ContactState, 'contactDatas'>;

const ContactTable = memo<ContactTableProps>(({ contactDatas }) => (
    <table className="table is-fullwidth">
        <thead>
            <tr>
                <th>Customer No.</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Contact Type</th>
                <th>Contact Address</th>
            </tr>
        </thead>
        <tbody>
            {contactDatas.map((f) => (
                <tr key={f.id}>
                    <td>{f.id}</td>
                    <td>{f.firstName}</td>
                    <td>{f.lastName}</td>
                    <td>{f.contactType}</td>
                    <td>{f.contactAddress}</td>
                </tr>
            ))}
        </tbody>
    </table>
));

ContactTable.displayName = 'ContactTable';

export default ContactTable;
