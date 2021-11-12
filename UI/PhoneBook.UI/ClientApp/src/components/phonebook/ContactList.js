import React from 'react';
import { Card, CardTitle, CardBody, Table, Button, Row, Col } from 'reactstrap';

const ContactList = props => (

    <div>        
        <Card>
            <CardBody>
                <CardTitle><Row><Col md={10}>Contact list </Col><Col md={2} class="float-right"><Button color="success"><i class="bi bi-person-plus float-right"></i></Button></Col></Row></CardTitle>
                <Table class= "table table-striped table-hover">
                    <tr>
                        <th>#</th>
                        <th>Name</th>
                        <th>Phone number</th>
                        <th></th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>Moses</td>
                        <td>0761837900</td>
                        <td><Button color="danger"><i class="bi bi-trash"></i></Button></td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>Lephatse</td>
                        <td>0761564900</td>
                        <td><Button color="danger"><i class="bi bi-trash"></i></Button></td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>Moshe</td>
                        <td>0761833900</td>
                        <td><Button color="danger"><i class="bi bi-trash"></i></Button></td>
                    </tr>
                </Table>

            </CardBody>
        </Card>
    </div>
);

export default ContactList;