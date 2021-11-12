import React from 'react';
import 'bootstrap-icons/font/bootstrap-icons.css'
import { Form, Card, CardBody, CardTitle, FormGroup, Row, Col, Label, Input, Button } from 'reactstrap';

const Login = props => (

    <div>
        <Row md={ 12}>
            <Col md={ 6}>
                <Card>
                    <CardBody>
                        <CardTitle>Login</CardTitle>
                        <Form>
                            <FormGroup>
                                <Label>Username</Label>
                                <Input type="text" name="username" id="username" value={props.login.username} onChange={ props.handleInputChange}></Input>
                            </FormGroup>
                            <FormGroup>
                                <Label>Password</Label>
                                <Input type="password" name="password" id="password" value={props.login.password} onChange={props.handleInputChange}></Input>
                            </FormGroup>
                            <FormGroup>
                                <Button color="success" style={{ width: '100%' }} onClick={props.loginAsync}><strong>Login</strong></Button>
                            </FormGroup>
                        </Form>

                    </CardBody>
                </Card>
                <br/>
            </Col>

            <Col md={6}>
                <Card>
                    <CardBody>
                        <CardTitle>PhoneBook App - Welcome</CardTitle>
                        <CardBody>
                            <p>
                                Welcome to the PhoneBook App.
                                This app is designed to help you manage your contacts.
                            </p>

                            <p>
                                Please use the account assigned to you to access the
                                functionality to manage your contacts smoothly.Hope you have fun using the app.
                            </p>

                            <p>
                                <strong><i>For any issues and enquiries call Moses on 0761837904.</i></strong>
                            </p>

                            
                        </CardBody>
                    </CardBody>
                </Card>
            </Col>
        </Row>
    </div>
);

export default Login;