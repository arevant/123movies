import * as React from "react";
import { reduxForm, Field } from 'redux-form';
import { authenticate } from "../../apis/usersApi";
import "../../custom.css";
import TextField from "../../uicomponents/textfield/textfield";
import Button from "../../uicomponents/button/button";
import { SET_USER_PROFILE } from "../../store/actions/userprofile";
import { connect } from "react-redux";

const formValidators = {
  required: (value: any) => value ? undefined : 'Required'
}

let LoginForm: any = (props: any) => {
  const { handleSubmit, handleLogin, showInvalidUserMessage } = props;

  return (
    <div>
      {props.submitFailed && <div>All the fields are mandatory.</div>}
      <div className="m-2">
        <Field name='username' component={TextField} placeholder="Enter username" validate={formValidators.required} required={true} />
      </div>
      <div className="m-2">
        <Field name='password' component={TextField} placeholder="Enter password" type='password' validate={formValidators.required} required={true} />
      </div>
      {showInvalidUserMessage && (
        <div>
          <label style={{ color: "red" }}>Invalid Username or Password</label>
        </div>
      )}
      <div className="m-2">
        <Button label="Login" onClick={handleSubmit(handleLogin)}>
        </Button>
      </div>
    </div>
  )
}

LoginForm = reduxForm({
  form: 'loginForm',
  enableReinitialize: true
})(LoginForm)

const Login: React.FC = (props: any) => {
  const [showInvalidUserMessage, setShowInvalidUserMessage] = React.useState(false);

  const handleLogin = async (values: any) => {
    setShowInvalidUserMessage(false);
    const result = await authenticate(values.username, values.password);
    if (!result.data.token) {
      setShowInvalidUserMessage(true);
    } else {
      const userDetails = result.data.user;
      props.setUserProfile(userDetails);
      props.history.push('/');
    }
  };

  return (
    <div className="container-fluid loginContainer">
      <h2 className="loginHeader">Welcome to 123Movies!</h2>

      <LoginForm handleLogin={handleLogin} showInvalidUserMessage={showInvalidUserMessage} />
    </div>
  );
};

const mapStateToProps = (state: any) => {
  return {};
}

const mapDispatchToProps = (dispatch: any) => {
  return {
    setUserProfile: (userProfile: any) => {
      dispatch({ type: SET_USER_PROFILE, value: userProfile });
    }
  }
}
export default connect(mapStateToProps, mapDispatchToProps)(Login);