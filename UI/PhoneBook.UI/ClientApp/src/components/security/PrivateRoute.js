import React from 'react'
import {
    Route,
    Redirect,
} from 'react-router-dom'

const tokenService = require('./TokenService');

const PrivateRoute = ({ component: Component, role, ...rest }) => (
    <Route {...rest} render={(props) => {

        const user = tokenService.getToken();

        if (!user) {

            return <Redirect to={{ pathname: '/login', state: { from: props.location } }} />
        }

        return <Component {...props} />
    }
   } />
)

export default PrivateRoute;