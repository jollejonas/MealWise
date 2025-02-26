import React from 'react';
import { Modal } from 'react-bootstrap';

const UserModal = ({ show, handleClose, isRegister, formComponent: FormComponent }) => {
    return (
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>{isRegister ? 'Register' : 'Login'}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <FormComponent onSuccess={handleClose} />
            </Modal.Body>
        </Modal>
    );
};

export default UserModal;
