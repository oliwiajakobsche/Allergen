import {StyleSheet} from 'react-native';

const styles = StyleSheet.create({
    date: {    
        flex: 1,
        textAlign: 'center',
        backgroundColor: '#c1eba7cf',
        borderRadius: 10,
        textAlignVertical: 'center',
        fontSize: 16,
        maxWidth: '50%'
    },
    arrowLeft: {
        textAlign: 'right',
        color: '#68d525',
        fontWeight: 'bold',        
        fontSize: 26
    },
    arrowRight: {
        textAlign: 'left',
        color: '#68d525',
        fontWeight: 'bold',
        fontSize: 26
    },
    container: {        
        flexDirection: 'row',
        padding: 5,
        paddingLeft: 15,
        paddingRight: 15,
        borderBottomWidth: 1,
        borderColor: 'rgba(208, 237, 201,1)',
        borderWidth: 1,
        backgroundColor: 'rgba(208, 237, 201,0.2)'
    },
    label: {      
        fontSize: 15,
        fontWeight: '500',
        color: 'rgba(31, 31, 31, 0.7)',
        flex: 1
    },
    switch: {    
        flex: 1
    },
    arrowRightOpacity: {
        flex: 1,
        textAlign: 'right',
        borderWidth: 1,
        borderColor: 'rgba(31, 31, 31, 0.7'
    },
    arrowLeftOpacity: {
        flex: 1,
        textAlign: 'left',
    }
  });

export default styles;