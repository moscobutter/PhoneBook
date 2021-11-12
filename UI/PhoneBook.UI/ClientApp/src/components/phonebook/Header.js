import React from 'react';
import 'bootstrap-icons/font/bootstrap-icons.css'
import { Card, CardBody, CardTitle, InputGroup, Input, Button } from 'reactstrap';

const Header = props => (

    <div>
        
        <Card>
            <CardBody>
                <CardTitle>Search</CardTitle>
                <InputGroup>
                    <Input type="text" class="form-control" ></Input>
                    <Button color="success" ><i class="bi bi-search"></i></Button>
                </InputGroup>
                
            </CardBody>
        </Card>
    </div>
);

export default Header;