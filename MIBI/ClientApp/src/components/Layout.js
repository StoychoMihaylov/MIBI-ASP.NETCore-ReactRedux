import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import InfoMessageBox from '../components/InfoMessageBox'

export default props => (
  <div>
    <NavMenu />
    <InfoMessageBox />
    <Container>
      {props.children}
    </Container>
  </div>
);
