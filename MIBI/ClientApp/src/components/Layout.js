import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import Notification from '../components/Notification'

export default props => (
  <div>
    {
      localStorage.getItem("token") !== null
      ?
      <NavMenu />
      :
      null
    }
    <Notification/>
    <Container>
      {props.children}
    </Container>
  </div>
);
