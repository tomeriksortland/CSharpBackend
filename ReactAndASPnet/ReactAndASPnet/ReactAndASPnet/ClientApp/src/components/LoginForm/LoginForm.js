import React from 'react';
import { Button } from 'react-bootstrap'
import { Form } from 'react-bootstrap'
import { Container } from 'react-bootstrap'
import { Row } from 'react-bootstrap'
import './LoginForm.css'

const input = () => {
    return (
    <Container>
        <Row>
            <Form>
                <Form.Group controlId="formBasicEmail">
                <Form.Label htmlFor="email">Email Adress</Form.Label>
                <Form.Control 
                type="email" 
                className="mx-sm-3"
                placeholder="Enter Email!"
               />
           </Form.Group>
        

            <Form.Group controlId="formBasicPassword">
                <Form.Label htmlFor="pass">Password</Form.Label>
                <Form.Control 
                type="password" 
                className="mx-sm-3"
                placeholder="Password!"
                />
            </Form.Group>
                <Button variant="info" type="submit">Login</Button>
                <Button variant="danger" type="register">Sign Up!</Button>
            </Form>
        </Row>
    </Container>
    )
}

export default input;