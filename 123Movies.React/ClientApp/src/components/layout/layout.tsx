import * as React from 'react';
import { Container } from 'reactstrap';
import NavMenu from '../navmenu/navmenu';

export default class Layout extends React.PureComponent<{}, { children?: React.ReactNode }> {
    public render() {
        return (
            <React.Fragment>
                <NavMenu />
                <Container className={"container"}>
                    {this.props.children}
                </Container>
            </React.Fragment>
        );
    }
}