import React from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/PhoneBookManagement';
import Header from './phonebook/Header';
import ContactList from './phonebook/ContactList';

import { Card, CardHeader, CardBody, CardFooter, Row, Col } from 'reactstrap';

const PhoneBookManager = props => (
    <div>
        <Row md={ 12}>
            <Col md={ 8}>
                <Card>
                    <CardHeader>Contacts</CardHeader>
                    <CardBody>
                        {Header(props)}
                        <br />
                        {ContactList(props)}
                    </CardBody>
                    <CardFooter>PhoneBook Company &copy; {(new Date()).getFullYear()}</CardFooter>
                </Card>
            </Col>
        </Row>
    </div>
    
);

export default connect(
    state => state.phonebookmanager,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(PhoneBookManager);
