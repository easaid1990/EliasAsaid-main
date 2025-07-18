import React, { useEffect, useState } from "react";
import { User } from "../shared/User";

export const Example: React.FC = () => {
    const [users, setUsers] = useState<User[]>([]);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        document.title = "Example - My React Application";
    }, []);

    const loadUsers = async () => {
        setLoading(true);
        try {
            const response = await fetch('/api/user/list');
            if (!response.ok) {
                throw new Error('Failed to fetch users');
            }
            const data = await response.json();
            setUsers(data);
        } catch (error) {
            console.error('Error loading users:', error);
            alert('Error loading users. Please try again later.');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <h2>Example</h2>
            <div className="row">
                <div className="col-lg-12">
                    <div className="tb-container">
                        <table className="table table-striped">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>First Name</th>
                                    <th>Last Name </th>
                                    <th>Email</th>
                                    <th>Date Created</th>
                                </tr>
                            </thead>
                            <tbody>
                                {users.map(user => (
                                    <tr key={user.id}>
                                        <td>{user.id}</td>
                                        <td>{user.first_name}</td>
                                        <td>{user.last_name}</td>
                                        <td>{user.email}</td>
                                        <td>{user.date_created}</td>
                                    </tr>
                                ))}
                            </tbody>
                        </table>
                    </div>
                    {loading && (
                        <div className="text-center my-3">
                            <div className="spinner-border text-info" role="status">
                                <span className="visually-hidden">Loading...</span>
                            </div>
                        </div>
                    )}
                    {!loading && users.length === 0 && (
                        <button
                            className="btn btn-info"
                            type="button"
                            id="addressSearch"
                            onClick={loadUsers}
                        >
                            Load Users
                        </button>
                    )}
                </div>
                </div>
            </div>
        );
    }
