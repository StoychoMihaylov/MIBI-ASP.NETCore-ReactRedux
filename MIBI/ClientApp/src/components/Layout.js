import React from 'react';
import { Container } from 'reactstrap';
import NavMenu from './NavMenu';
import InfoMessageBox from '../components/InfoMessageBox'

export default props => (
  <div>
    <NavMenu />
    <Container>
      <InfoMessageBox />
      {props.children}
    </Container>
  </div>
);
