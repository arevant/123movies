import * as React from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './navmenu.css';
import { connect } from 'react-redux';

class NavMenu extends React.Component<any, any> {
    public state = {
        isOpen: false,
        userProfile: null
    };

    public render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm border-bottom box-shadow mb-3" light>
                    <Container>
                        <NavbarBrand tag={Link} to="/" className={`cursor-pointer`}>123Movies</NavbarBrand>
                        <NavbarToggler onClick={this.toggle} className="mr-2" />
                        <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={this.state.isOpen} navbar>
                            <ul className="navbar-nav flex-grow">
                                <NavItem>
                                    <NavLink tag={Link} className="text-dark cursor-pointer" to="/">Home</NavLink>
                                </NavItem>
                                {!this.props.userProfile && <NavItem>
                                    <NavLink tag={Link} className="text-dark cursor-pointer" to="/login">Login</NavLink>
                                </NavItem>}
                                {this.props.userProfile && <NavItem>
                                    <NavLink tag={Link} className="text-dark cursor-pointer" to="/logout">Logout</NavLink>
                                </NavItem>}
                            </ul>
                        </Collapse>
                    </Container>
                </Navbar>
            </header>
        );
    }

    private toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }
}

const mapStateToProps = (state: any) => {
    return {
        userProfile: state.userProfile.userProfile
    };
}

const mapDispatchToProps = (dispatch: any) => {
    return {
    }
}

export default connect(mapStateToProps, mapDispatchToProps)(NavMenu)
